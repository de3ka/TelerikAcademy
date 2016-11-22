<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <title>
        Students
      </title>
      <body>
        <h1>Students</h1>
        <ul>
          <xsl:for-each select="studentsystem/student">
            <li>
              <div>
                Name: <xsl:value-of select="name"/>
              </div>
              <div>
                Sex: <xsl:value-of select="sex"/>
              </div>
              <div>
                Birthdate: <xsl:value-of select="birthdate"/>
              </div>
              <div>
                phone: <xsl:value-of select="phone"/>
              </div>
              <div>
                email: <xsl:value-of select="email"/>
              </div>
              <div>
                course: <xsl:value-of select="course"/>
              </div>
              <div>
                specialty: <xsl:value-of select="specialty"/>
              </div>
              <div>
                faculty number: <xsl:value-of select="facultynumber"/>
              </div>
              <ul>
                <xsl:for-each select="exams/exam">
                  <li>
                    <div>
                      exam name: <xsl:value-of select="examname"/>
                    </div>
                    <div>
                      tutor name: <xsl:value-of select="tutorname"/>
                    </div>
                    <div>
                      score: <xsl:value-of select="score"/>
                    </div>
                  </li>
                </xsl:for-each>
              </ul>
            </li>
          </xsl:for-each>
        </ul>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>